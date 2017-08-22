
# Backlog4net

![Build Status on VSTS](https://ats124.visualstudio.com/_apis/public/build/definitions/6d2503dc-7657-4a46-937e-3fac285bb430/1/badge)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

Backlog4net is a port of Backlog4j.

* Backlog4j
  * [https://github.com/nulab/backlog4j](https://github.com/nulab/backlog4j)

## Installation

Getting started from downloading NuGet packages.

```
PM> Install-Package backlog4net
```

## Usage

```C#
using Backlog4net;
using Backlog4net.Api
using Backlog4net.Api.Option
using Backlog4net.Conf
```

```C#
async Task Main()
{
    var conf = new BacklogJpConfigure("space_key");
    conf.ApiKey = "api_key";
    var backlogClient = new BacklogClientFactory(conf).NewClient();
    var issue = await backlogClient.CreateIssueAsync(
        new CreateIssueParams(12345, "issue-title", 1111, IssuePriorityType.Normal)
        {
            Description = "issue-description",
        });
}
```

## License

[MIT](LICENSE)
