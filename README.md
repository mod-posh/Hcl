# C# Project

Enclosed are the files I use to build and deploy C# Projects. The basic file structure is included so you know what it should look like. Several Modules are required, and the Tasks will check for them at the start.

## Dependencies

You will need to have the following modules installed:

 1. PowerShellForGitHub : This is used for the ReleaseNotes task.
 2. DefaultDocumentation: This is used to generate code documentation from comments.

Please see the [psakefile](psakefile.ps1) for the versions currently used.

## Supporting Files

There are several files used to help authenticate to various services, and depending on your needs, you may not need them or need something different. You can use them as is, but you must populate the various tokens and keys yourself. Also, you can use them as a template if you need nothing.

### ado.json

This file is used to authenticate into the Azure DevOps Rest API, and you will need a token for this, so please consult the [Documentation](https://learn.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=azure-devops&tabs=Windows). I include three items:

1. Orgname    : The name of the Azure DevOps organization.
2. Token      : The PAT Token.
3. Expiration : The expiration date.

I include the Expiration so I can get a visual indication of how long before I need to renew the token; there is logic within the psakefile to display that out when you run it.

### discord.json

This file is used to post a message to Discord. I have a server that I set up, and I post updates to channels for each module I use. If you wish to use the Post2Discord task, you must have a Discord account, set up a personal server, and get the webhook URL; please consult the [Documentation](https://support.discord.com/hc/en-us/articles/228383668-Intro-to-Webhooks).

### github.json

This file is used to authenticate into the GitHub API; you must set up a token for this, so please consult the [Documentation](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token). This file is also used for the ReleaseNotes task.

### blueksy.json

This file is used to authenticate into the Bluesky Social Media platform. You must set up a token for this, so please consult the [Documentation](https://github.com/bluesky-social/atproto-ecosystem/blob/main/app-passwords.md).

### nuget.config

This file is initially set up to publish to nuget.org and the PowerShell Gallery. You must create an API Key for this. Please consult the [Documentation](https://learn.microsoft.com/en-us/powershell/scripting/gallery/concepts/publishing-guidelines?view=powershell-7.3).

> [!Caution]
> You will want to add ado.json, discord.json, github.json, bluesky.json to your .gitignore before any commits
> those files contain sensitive information such as passwords and credentials, they are provided here to give
> you a place to start

## PsakeFile

This is the main file from which all automation is kicked off. I will go through the basic usage of this file, but for details on setting it up for your use, please refer to the file itself. The Psakefile contains a collection of Tasks. For more information on setting up and using Psake, please consult the [Documentation](https://psake.readthedocs.io/en/latest/). I will cover the basic tasks that I use so you have an understanding of how they work.

### Localuse

This task is run regularly, compiling the module after local changes so I can test functionality. It runs a Build but does not do any testing that would typically accompany it.

### Build

This task runs the LocalUse and TestProject tasks, so make sure you have some of those; otherwise, remove the reference to the TestProject Task. For more information on setting up Tests, please refer to the [Documentation](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit).

### Package

This task builds the help files, packages them up for deployment, and updates the README.

### Deploy

This task will check to make sure we have checked out the Deployment Branch, and the deployment should fail if we are not in the deployment branch. It will then create the Release Notes, compiled from the GitHub Milestones; if you are not using them, remove the reference to this task. It will then Publish the project to nuget.org, create and push a Tagged release, and create the GitHub Release.

### Notifications

This task will post updates to any notification channels you have set up; Post2Discord and Post2BlueSky are the defaults.
