Запуск Проекта

Для запуска проекта локально выполните следующие шаги:
1) Клонируйте репозиторий.
2) Настройте базу данных:
 - По умолчанию проект настроен на использование PostgreSQL. Убедитесь, что у вас установлен и запущен PostgreSQL-сервер.
 - Обновите строку подключения в файле appsettings.json в корне проекта OrderDeliveryApp.
 - В строке "DefaultConnection": "Host=localhost;Port=5432;Database=ordersdb;Username=your_username;Password=your_password" замените your_username и your_password на ваши учетные данные PostgreSQL.
   
3) Запустите приложение.
