using System.Reflection;
using System.Runtime.InteropServices;

// 어셈블리에 대한 일반 정보는 다음 특성 집합을 통해 
// 제어됩니다. 어셈블리와 관련된 정보를 수정하려면
// 이러한 특성 값을 변경하세요.
[assembly: AssemblyTitle("Windows Subsystem for Linux Distro Manager")]
[assembly: AssemblyDescription("This program helps you manage Linux packages for Windows Subsystem for Linux.")]
#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else
[assembly: AssemblyConfiguration("RELEASE")]
#endif
[assembly: AssemblyCompany("rkttu.com")]
[assembly: AssemblyProduct("Windows Subsystem for Linux Distro Manager")]
[assembly: AssemblyCopyright("Copyright (c) 2019 rkttu.com, All rights reserved.")]
[assembly: AssemblyTrademark("rkttu.com")]
[assembly: AssemblyCulture("")]

// ComVisible을 false로 설정하면 이 어셈블리의 형식이 COM 구성 요소에 
// 표시되지 않습니다. COM에서 이 어셈블리의 형식에 액세스하려면
// 해당 형식에 대해 ComVisible 특성을 true로 설정하세요.
[assembly: ComVisible(false)]

// 이 프로젝트가 COM에 노출되는 경우 다음 GUID는 typelib의 ID를 나타냅니다.
[assembly: Guid("e3395aa1-1245-4302-b212-a2ddeb68d0ae")]

// 어셈블리의 버전 정보는 다음 네 가지 값으로 구성됩니다.
//
//      주 버전
//      부 버전 
//      빌드 번호
//      수정 버전
//
// 모든 값을 지정하거나 아래와 같이 '*'를 사용하여 빌드 번호 및 수정 번호를
// 기본값으로 할 수 있습니다.
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
