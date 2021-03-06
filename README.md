# PetStore Setup
To run the projects in this solution you will need to install 
these <a href="https://lazystack.io/installation/installation_visualstudio.html">prerequisites</a>.
This PetStore solution contains an AWS Serverless Stack and a simple client applications.
- PetStoreConsoleApp -- a simple console applciation

Then follow these steps:
1. Open the solution in Visual Studio (Windows)
2. Open the LazyStacks.yaml file and edit the Region and Profile name in the Stacks.Dev element.
3. Select Visual Studio menuitem "Tools/LazyStack - Generate Projects". The projects and configuration files are updated.
4. Rebuild the solution. Ignore the errors for PetStoreConsoleApp
5. Navigate to the Stacks\Dev folder.
6. Right click on the serverless.template and select Publish to AWS. Your stack is created on AWS.
7. Select Visual Studio menuitem "Tools/LazyStack - Generate Stacks\Dev\AwsSettings.json". 
8. Rebuild the solution. PetStoreConsoleApp should not throw an error.
9. You many now run the PetStoreConsoleApp project.

For a more detailed review of this project, visit the <a href="https://lazystack.io/tutorial/tutorial_intro.html">LazyStack Visual Studio Tutorial</a>.



