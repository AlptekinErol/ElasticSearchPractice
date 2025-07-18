
# 🚀 ElasticSearchPractice

## 📦 Proje Açıklaması

Bu proje, **.NET 8 Web API** ile geliştirilmiş bir **ElasticSearch CRUD servisidir**.

### İçerdiği Bileşenler:

- Katmanlı mimari (API, Application, Domain, Infrastructure)
- Elastic.Clients.Elasticsearch 9.0.7
- Kibana görsel veri yönetimi
- FluentValidation (Request doğrulama)
- Serilog (Loglama)
- HealthCheck (ElasticSearch kontrolü)

---

## 🗂️ Klasör Yapısı

```
src/
├── Project.Api               -> API Katmanı (Controller, Program.cs)
├── Project.Application       -> İş Mantığı, Services, Interfaces
├── Project.Domain            -> Entity (Product)
├── Project.Infrastructure    -> ElasticSearch işlemleri (Repository, Client)
```

---

## ⚙️ Kurulum

### 1️⃣ Docker ile ElasticSearch & Kibana Çalıştırma

`docker-compose.yml`:

```yaml
services:
  elasticsearch:
    image: elasticsearch:9.0.3
    environment:
      - xpack.security.enabled=false
      - "discovery.type=single-node"
    ports:
      - 9200:9200
    volumes:
      - elasticsearch-data:/usr/share/elasticsearch/data

  kibana:
    image: kibana:9.0.3
    ports:
      - 5601:5601
    environment:
      - ELASTICSEARCH_HOST=http://elasticsearch:9200

volumes:
  elasticsearch-data:
    driver: local
```

#### Çalıştır:

```bash
docker compose up -d
```

---

### 2️⃣ API Projeyi Çalıştır

```bash
dotnet build
dotnet run --project src/Project.Api
```

Swagger Arayüzü:  
[http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 🔗 API Endpointleri

| Method | Endpoint               | Açıklama               |
|---------|------------------------|------------------------|
| POST    | `/api/products`         | Yeni ürün ekler         |
| GET     | `/api/products`         | Ürünleri listeler       |
| PUT     | `/api/products`         | Ürün günceller          |
| DELETE  | `/api/products/{id}`    | Ürün siler              |
| POST    | `/api/products/seed`    | 100 adet sahte veri ekler |
| GET     | `/health`               | ElasticSearch kontrolü |

---

## 🔍 Kibana Dashboard

Kibana Arayüzü:  
[http://localhost:5601](http://localhost:5601)

### Discover için:

1. **Stack Management > Index Patterns**  
2. Yeni pattern oluşturun:

```
products*
```

3. Discover menüsünde verilerinizi görebilirsiniz.

---

## 🧰 Kullanılan Teknolojiler

- .NET 8 Web API  
- ElasticSearch 9.0.3  
- Elastic.Clients.Elasticsearch 9.0.7  
- Kibana 9.0.3  
- FluentValidation  
- Serilog  
- Bogus (Sahte veri üretimi)  
- Docker / Docker Compose  

---

## ElasticSearchPractice - Roadmap

✅ Basic CRUD & Search  
✅ Docker + Kibana setup  
🟢 Next: Nested Query  
🟢 Next: Range Query  
🔵 Future: Aggregation & Analytics  
🔵 Future: Ingest Pipeline  

## 📝 Geliştiren

Alptekin Erol  
ElasticSearchPractice Projesi - 2025
