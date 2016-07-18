[1mdiff --cc ITP311/ITP311.csproj[m
[1mindex 5269367,e20c76f..0000000[m
[1m--- a/ITP311/ITP311.csproj[m
[1m+++ b/ITP311/ITP311.csproj[m
[36m@@@ -119,7 -122,30 +122,34 @@@[m
      <Compile Include="adminportal_createDoc.aspx.designer.cs">[m
        <DependentUpon>adminportal_createDoc.aspx</DependentUpon>[m
      </Compile>[m
[32m++<<<<<<< HEAD[m
[32m +    <Compile Include="App_Code\BLL\AccountBLL.cs" />[m
[32m++=======[m
[32m+     <Content Include="App_Code\BLL\AccountBLL.cs" />[m
[32m+     <Compile Include="App_Code\DAL\PatientsLogDAL.cs" />[m
[32m+     <Compile Include="App_Code\BLL\PatientsLogBLL.cs" />[m
[32m+     <Compile Include="CreatePatientsLog.aspx.cs">[m
[32m+       <DependentUpon>CreatePatientsLog.aspx</DependentUpon>[m
[32m+       <SubType>ASPXCodeBehind</SubType>[m
[32m+     </Compile>[m
[32m+     <Compile Include="CreatePatientsLog.aspx.designer.cs">[m
[32m+       <DependentUpon>CreatePatientsLog.aspx</DependentUpon>[m
[32m+     </Compile>[m
[32m+     <Compile Include="doctor-index.aspx.cs">[m
[32m+       <DependentUpon>doctor-index.aspx</DependentUpon>[m
[32m+       <SubType>ASPXCodeBehind</SubType>[m
[32m+     </Compile>[m
[32m+     <Compile Include="doctor-index.aspx.designer.cs">[m
[32m+       <DependentUpon>doctor-index.aspx</DependentUpon>[m
[32m+     </Compile>[m
[32m+     <Compile Include="doctor-PatientsLog.aspx.cs">[m
[32m+       <DependentUpon>doctor-PatientsLog.aspx</DependentUpon>[m
[32m+       <SubType>ASPXCodeBehind</SubType>[m
[32m+     </Compile>[m
[32m+     <Compile Include="doctor-PatientsLog.aspx.designer.cs">[m
[32m+       <DependentUpon>doctor-PatientsLog.aspx</DependentUpon>[m
[32m+     </Compile>[m
[32m++>>>>>>> 22c14e9605563ccf35706153ede2134218b173b8[m
      <Compile Include="WebForm1.aspx.cs">[m
        <DependentUpon>WebForm1.aspx</DependentUpon>[m
        <SubType>ASPXCodeBehind</SubType>[m
