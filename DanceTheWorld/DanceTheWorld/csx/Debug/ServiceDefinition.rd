<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="DanceTheWorld" generation="1" functional="0" release="0" Id="99de2062-c30a-46d6-87ec-0e8746b7da43" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="DanceTheWorldGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="DanceTheWorld_WebRole:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/DanceTheWorld/DanceTheWorldGroup/LB:DanceTheWorld_WebRole:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="DanceTheWorld_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/DanceTheWorld/DanceTheWorldGroup/MapDanceTheWorld_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="DanceTheWorld_WebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/DanceTheWorld/DanceTheWorldGroup/MapDanceTheWorld_WebRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:DanceTheWorld_WebRole:Endpoint1">
          <toPorts>
            <inPortMoniker name="/DanceTheWorld/DanceTheWorldGroup/DanceTheWorld_WebRole/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapDanceTheWorld_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/DanceTheWorld/DanceTheWorldGroup/DanceTheWorld_WebRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapDanceTheWorld_WebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/DanceTheWorld/DanceTheWorldGroup/DanceTheWorld_WebRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="DanceTheWorld_WebRole" generation="1" functional="0" release="0" software="D:\Projects\DanceTheWorld\DanceTheWorld\csx\Debug\roles\DanceTheWorld_WebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;DanceTheWorld_WebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;DanceTheWorld_WebRole&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/DanceTheWorld/DanceTheWorldGroup/DanceTheWorld_WebRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/DanceTheWorld/DanceTheWorldGroup/DanceTheWorld_WebRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/DanceTheWorld/DanceTheWorldGroup/DanceTheWorld_WebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="DanceTheWorld_WebRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="DanceTheWorld_WebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="DanceTheWorld_WebRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="c7a9da26-5913-4dbd-a9fe-71fbdda250e9" ref="Microsoft.RedDog.Contract\ServiceContract\DanceTheWorldContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="ad8370ee-0e21-4980-8f5f-5e31a274f8be" ref="Microsoft.RedDog.Contract\Interface\DanceTheWorld_WebRole:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/DanceTheWorld/DanceTheWorldGroup/DanceTheWorld_WebRole:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>