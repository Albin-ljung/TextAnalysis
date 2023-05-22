# TextAnalysis

## Get started 

### Build and run the project 
1. Start by cloning the project to your local computer, open the project with either Visual studio or visual studio code. 
2. With Visual studio just run the application with the TextAnalysis.Web project as startup project. With Visual Studio Code, run the project with "dotnet run" from the same web project.
3. The Application is using Swagger, so you can do request with either that or using "rest client" extension inside VSCode. There is alerady some http files under /Request that you can use.

### What does it do?
There is an Api endpoint for posting an sentence, this sentence will be processed and every word will be extracted can calculated with word frequncy in the sentence.
We response with the direct result of that calculation, but we also store the sentence in the database in "Sentence" table. We also store the "Common word" with its frequency in another table
called "CommonWords". Everytime we post a new sentence we add or update the words in this CommonWords table so its up to date. We can then query this table to 
get the statistics of what the most common words are.

There is also an Api for posibillity to search for a word, this api will return all the words containing that searchphrase. 

### Project
The project is inspired by Clean architecture with some of Steve Smiths(Ardalis) nuget packages. 
