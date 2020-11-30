DB ayarlari için;
appsettings.json dosyasındaki ConnectionStrings ayarlarını localhosta göre düzenledikten sonra Article.Infrastructure projesini Set as Startup Proje olarak seçiyoruz.
Package console managerden defaultproject olarak Article.Infrastructure seçiyoruz ve updata-database komutu ile DBnin create işlemlerini tamamlıyoruz.

-Daha önce de Loggin ve Document Service projelerinde yer aldım. Logging için Sentry entegrasyonu kullandıık. Monitoringini de buradan sağlıyoruz.

-Projece Repository Pattern kullanılmıştır.
Database işlemlerini tek bir yerden kontrol etmek için kullanılmıstır.

-Yeterli vakit olsaydı DBContextler için Dactory pattern kullanılabilirdi. Farklı connectionStringler için.

