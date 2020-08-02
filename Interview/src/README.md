#### Read me: 
Developed with VS Code 

###### Dependencies: 
VS Code
Omnisharp C# extension
3.1 Net Core Runtime
NUNIT tests/.Net Core Test Explorer [you can find this in extensions for VSCode]


###### How to run:

Terminal -> new terminal
Type or paste the following: 
<ol>
<li>dotnet restore </li>
<li>dotnet build </li>
<li>dotnet run </li>
</ol>

###### Design Decisions:
<ol>
<li>.Net core console app used as UI.</li>
<li>Console.WriteLine() is used to print an empty line in the terminal</li>
<li>If you enter the same name (not case sensative) as an item existing already it is going to use the values of the item already entered.</li>
<li>Using the default .net formatter for VS code, it's not the cleanest, nor do I particularily like how it formats.</li>
<li>The class using the most business logic is the receipt printer, but since we're using a void return type and dumping to the console it's not very easy to test for the correct output with a unit test, this issue wouldn't exist in the read world with a client/service implementation. </li>
<ol>


