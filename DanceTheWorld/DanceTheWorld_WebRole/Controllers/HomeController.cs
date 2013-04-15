using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DanceTheWorld_Data;
using DanceTheWorld_Repository;
using DanceTheWorld_WebRole.Models;
using Newtonsoft.Json;

namespace DanceTheWorld_WebRole.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(string startYear, string endYear)
        {
            List<Song> songs = await SongsRepository.Get(startYear, endYear);
            HomeModel model = new HomeModel();
            model.SongsMarkers = JsonConvert.SerializeObject(Clasterize(songs));
            return View(model);
        }


        const int _minX = -180;
        const int  _maxX = 180;

        const int _minY = -90;
        const int _maxY = 90;

        const int _colsCount = 60;
        const int _rowsCount = 60;

        public List<Claster> Clasterize(List<Song> songs)
        {
            int[,] matrix = new int[_rowsCount, _colsCount];
            PointF[,] matrixCoord = new PointF[_rowsCount, _colsCount];
            for (int i = 0; i < _rowsCount; i++)
            {
                for (int j = 0; j < _colsCount; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            for (int i = 0; i < _rowsCount; i++)
            {
                for (int j = 0; j < _colsCount; j++)
                {
                    matrixCoord[i, j] = Point.Empty;
                }
            }

            foreach (var song in songs)
            {
                bool br = false;
                for (int i = 0; i < _rowsCount; i++)
                {
                    if (br)
                        break;
                    for (int j = 0; j < _colsCount; j++)
                    {
                        if (IsInClaster(song, i, j))
                        {
                            matrix[i, j]++;
                            br = true;
                            if (matrixCoord[i, j].IsEmpty)
                                matrixCoord[i, j] = new PointF((float)song.Longitude, (float)song.Latitude);
                            break;
                        }
                    }
                }
            }

            float w = (_maxX - _minX) / _colsCount;
            float h = (_maxX - _minX) / _rowsCount;

            List<Claster> clasters = new List<Claster>();
            for (int i = 0; i < _rowsCount; i++)
            {
                for (int j = 0; j < _colsCount; j++)
                {
                    if (matrix[i, j] > 0)
                        clasters.Add(new Claster() { Size = matrix[i, j], Weight = CalculateClasterWeight(i, j, matrix), Longitude = matrixCoord[i, j].X, Latitude = matrixCoord[i, j].Y });
                }
            }

            return clasters;
        }

        private int CalculateClasterWeight(int i, int j, int[,] matrix)
        {
            int weight = 0;
            int max = GetMaxOfMatrix(matrix);
            if (matrix[i, j] * 100 / max < 5)
            {
                weight = 1;
            }
            else if (matrix[i, j] * 100 / max < 25)
            {
                weight = 2;
            }
            else if (matrix[i, j] * 100 / max < 60)
            {
                weight = 3;
            }
            else if (matrix[i, j] * 100 / max < 85)
            {
                weight = 4;
            }
            else
            {
                weight = 5;
            }
            return weight;
        }

        private int GetMaxOfMatrix(int[,] matrix)
        {
            int max;
            max = matrix[0,0];
            for (int i = 0; i < _rowsCount; i++)
            {
                for (int j = 0; j < _colsCount; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
            }
            return max;
        }

        private bool IsInClaster(Song song, int i, int j)
        {
            float x1, y1, x2, y2 = 0;
            float w = (_maxX - _minX) / _colsCount;
            float h = (_maxX - _minX) / _rowsCount;

            x1 = w * (j-1) - 180;
            x2 = x1 + w;

            y1 = h * (i-1) - 90;
            y2 = y1 + h;

            return song.Longitude >= x1 && song.Longitude <= x2 && song.Latitude >= y1 && song.Latitude <= y2;
        }
    }
}
