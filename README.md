# Clothes Online Shop

Приложение основано на ASP.NET CORE Framework и состоит из двух частей: веб-приложения и базы данных https://github.com/OlegVorontsov/Clothes_Online_Shop.DB. Обе части взаимодействуют с использованием ядра Entity Framework (EF). Все классы и зависимости поддерживаются внедрением Dependency Injection (DI).

Используемые технологии и библиотеки
- ASP.NET CORE
- шаблон Model-View-Controller (MVC)
- макет Figma https://www.figma.com/design/l6HRdu1usScu4tFsS9yYsS/Интернет-магазин---Одежда-(Copy)?node-id=101-2&t=wkpufp6CXH8JpyJV-0
- Razor pages
- Bootstrap
- HTML, CSS, JS
- LINQ
- MS SQL Server
- Entity Framework (EF)
- ASP.NET Identity (система аутентификации и авторизации)
- Serilog (журналы для диагностики)

## База Данных
Все объекты хранятся в базе данных Microsoft SQL Server. База данных имеет два контекста: базу данных и идентификатор. Первый выделяет объекты, связанные с продуктами и заказами. Второй отвечает за авторизацию, регистрацию и права, которые управляются с помощью ASP.NET Identity.

## Веб-приложение
Веб-приложение основано на шаблоне Model-View-Controller (MVC). Модели между базой данных и представлением сопоставляются вручную. Все представления используют Razor pages и Bootstrap.

## Права
### Администратор имеет следующие права:
- добавление / удаление / изменение товаров;
- просмотр всех заказов / обновление статуса / удаление заказов;
- редактирование пользователей и их прав.

### Зарегистрированный пользователь имеет следующие права:
- редактирование персональных данных;
- просмотр своих заказов;
- просмотр карточки товара;
- оформление заказа;
- добавлние товара в избранное.

### Незарегистрированный пользователь имеет следующие права:
- просмотр карточки товара;
- оформление заказа.

Для тестирования области администратора, пожалуйста, используйте следующие данные:
Электронная почта администратора = "admin@gmail.com"; Пароль администратора = "qwerHELP1986!";

### Отладка
Чтобы облегчить процесс отладки, была использована библиотека Serilog.

### Запуск приложения
Для запуска приложения рекомендуется использовать Visual Studio 2019. Для работы приложения скачайте также БД https://github.com/OlegVorontsov/Clothes_Online_Shop.DB

## Home page

![1](https://github.com/OlegVorontsov/Clothes_Online_Shop/assets/102809790/b8969332-4dd1-44ed-ad17-91b1d4d5c1c5)

![2](https://github.com/OlegVorontsov/Clothes_Online_Shop/assets/102809790/959abec6-cf40-452b-856d-8e0f7678e23e)

## Product page

![Снимок](https://github.com/OlegVorontsov/Clothes_Online_Shop/assets/102809790/292829ca-7373-4fe4-8688-17303ded2924)


## Login page

![3](https://github.com/OlegVorontsov/Clothes_Online_Shop/assets/102809790/7ddf6067-569c-4901-8e72-8014e053ab93)

## Admin area

![4](https://github.com/OlegVorontsov/Clothes_Online_Shop/assets/102809790/6ebe9081-79b0-4f19-8d3a-9fa3e9cdbe1b)

## Cart page

![cart](https://github.com/OlegVorontsov/Clothes_Online_Shop/assets/102809790/82915cc7-fc87-4da4-a52d-3538fb249404)




