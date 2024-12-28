# Workshop.WebDriver.Basics
![main image](/Images/TItle.png) 

This project was prepared as a final version of Basic of WebDriver workshop project. The idea was to create a simple WebDriver project starting from Spahetti code and finishing with a simple test automation solution. All tests of this project are running in parrallel.

## How to run the tests

### Run from Visual Studio

1. Open "Test Explorer", top navigation menu Test --> Test Explorer (This step only required if you haven't opened it yet)
2. Select .runsettings file, top navigation menu Test --> Configure Run Settings --> Select Solution Wide runsettings File
3. Right click on test of group of the tests you want to run and select "Run" from context menu

### Run from Command Line

1. Open command line inside of the test project directory
2. Type the following command "dotnet test --settings prod.runsettings"