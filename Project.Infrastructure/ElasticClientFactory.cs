using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Configuration;

namespace Project.Infrastructure;
public static class ElasticClientFactory
{
    public static ElasticsearchClient CreateClient(IConfiguration config)
    {
        var uri = config["Elastic:Uri"];
        var settings = new ElasticsearchClientSettings(new Uri(uri))
            .DefaultIndex("products");

        return new ElasticsearchClient(settings);
    }
}
