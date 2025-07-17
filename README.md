# 🚀 ElasticSearchPractice

## 📦 Proje Açıklaması

Bu proje, **.NET 8 Web API** ile geliştirilmiş bir **ElasticSearch CRUD servisidir**.  
Proje içerisinde:

- **Katmanlı mimari** (API, Application, Domain, Infrastructure)  
- **Elastic.Clients.Elasticsearch 9.0.7** client  
- **Kibana ile görsel veri yönetimi**  
- **FluentValidation** (Request doğrulama)  
- **Serilog** (Konsol & dosya loglama)  
- **HealthCheck** (ElasticSearch bağlantısı kontrolü)

---

## 🗂️ Klasör Yapısı

src/
├── Project.Api // API katmanı (Controller, Program.cs)
├── Project.Application // Business logic, Services, Interfaces
├── Project.Domain // Entity (Product)
├── Project.Infrastructure // ElasticSearch işlemleri (Repository, Client)
test/
├── Testler (isteğe bağlı)


---

## 🛠️ Kurulum

### 1️⃣ **Docker ile ElasticSearch + Kibana Çalıştır**

**docker-compose.yml**

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

---

Çalıştır:

bash
Copy
Edit
docker compose up -d

2️⃣ .NET API'yi Çalıştır
Proje dizininde:

bash
Copy
Edit
dotnet build
dotnet run --project src/Project.Api

Swagger arayüzü:

👉 http://localhost:5000/swagger

⚙️ API Endpointleri

| Method     | Endpoint             | Açıklama                        |
| ---------- | -------------------- | ------------------------------- |
| **POST**   | `/api/products`      | Yeni ürün ekler                 |
| **GET**    | `/api/products`      | Ürünleri listeler               |
| **PUT**    | `/api/products`      | Ürün günceller                  |
| **DELETE** | `/api/products/{id}` | Ürün siler                      |
| **POST**   | `/api/products/seed` | 100 adet sahte ürün ekler       |
| **GET**    | `/health`            | ElasticSearch bağlantı kontrolü |


🔍 Kibana Dashboard
Kibana arayüzü:
👉 http://localhost:5601

Discover Kısmında Veriyi Görmek İçin:
1- Stack Management > Index Patterns

2- Yeni bir pattern oluştur:

products*

3- Discover sekmesinde ürün verilerini görebilirsiniz.


🧰 Kullanılan Teknolojiler
.NET 8 Web API

ElasticSearch 9.0.3

Elastic.Clients.Elasticsearch 9.0.7

Kibana 9.0.3

FluentValidation

Serilog

Bogus

Docker / Docker Compose


