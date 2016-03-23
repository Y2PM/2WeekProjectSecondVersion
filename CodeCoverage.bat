Run tests
REM Make a 'reports' directory if it doesn’t exist already
mkdir .\reports
REM Run unit tests through OpenCover
.\packages\OpenCover.4.6.166\tools\OpenCover.Console.exe^
 -register:user^
 -target:"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\MSTest.exe"^
 -targetargs:"/noisolation /testcontainer:\"Tests\bin\Debug\Tests.dll\""^
 -mergebyhash^
 -output:.\reports\output.xml
REM Generate the report
.\packages\ReportGenerator.2.4.4.0\tools\ReportGenerator.exe^
 -reports:.\reports\output.xml^
 -targetdir:.\reports
REM Open the report
start .\reports\index.htm