# cookieclicker-tech-test

.NET automated UI test suite written using selenium/NUnit in the POM design pattern for the Airelogic cookieclicker game.

Tests can be run through the test explorer window or through using dotnet test command documented here: https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test

Prior to running any tests, you may need to designate the test settings to use the test.runsettings file. This file can also be used to change the URL/browser. Tests have mainly been developed using chrome but can also support testing on firefox and edge, see the TestConfig/DriverFactory.cs for more info.
