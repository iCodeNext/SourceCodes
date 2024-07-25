using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPerformance;
public record AppSettings
{
    [ConfigurationKeyName("aws:dynamoDb")]
    public Dynamodb Dynamodb { get; init; }
}
public record Dynamodb
{
    public string TableName { get; init; }
}


