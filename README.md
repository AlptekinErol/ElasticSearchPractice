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
src/
├── Project.Api -> API Katmanı (Controller, Program.cs)
├── Project.Application -> İş Mantığı, Services, Interfaces
├── Project.Domain -> Entity (Product)
├── Project.Infrastructure -> ElasticSearch işlemleri (Repository, Client)
