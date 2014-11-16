using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Church.TestingCommon;
using MSTestCaseExtensions;
using TestCaseProvider = Church.TestingCommon.TestCaseProvider;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Church.IntegrationTests")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Church.IntegrationTests")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("2025fe36-94b3-4a9b-a213-825d3c6b4cec")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: UnitTestAssembly]
[assembly: IgnoreDefaultTestCaseProviders]
[assembly: RegisterTestCaseProvider(typeof(TestCaseProvider))]
[assembly: RegisterTestCaseProvider(typeof(TestCaseSourceProvider))]
