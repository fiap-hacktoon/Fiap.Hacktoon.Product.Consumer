#nullable enable
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Fiap.Hackatoon.Product.Consumer.Domain.Entities.Interfaces;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.ElasticSearch;

public interface IElasticSearchService<T> : IDisposable where T : class, IBaseEntity
{
    Task<bool> Create(T log, IndexName index);
    Task Update(T document, string indexName);
    Task<IReadOnlyCollection<T>> Get(int page, int size, IndexName index);
    Task<IReadOnlyCollection<T>> Search(IndexName index, Func<QueryDescriptor<T>, QueryDescriptor<T>> query, int page = 0, int size = 10);
    Task<T?> GetByIdAsync(string index, Guid id);
    Task Remove(Guid id, string indexName);
}