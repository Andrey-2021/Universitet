## Разработка системы автоматизации учета оценок преподавателем. (заказали программу)

#### Проект:
- C#, Visual Studio 2022,
- WPF, MVVM
- БД MSSQL,
- Entity Framework Сore.

#### Реализовано:
1. Реализован паттерн MVVM с помощью интрефейсов для каждого View. (Фабрики окон (View) нет)
2. В контейнере регистрируются:
 - все ViewModel-и
 - все пары Interface-View

#### Прикреплено:
1. Задание  

##### Запуск программы.  
1) Настроить доступ к БД <-- смотрите пункт (1)О программе.  
2) При ПЕРВОМ запуске программы, когда нет ещё БД, надо ввесть логин/пароль admin/admin

Программа запустится  
и надо создать новую БД в МЕНЮ Администратор  

##### О программе.  
1) Программа может работать как с MSSQL так и с MySQL БД.  
С чем работаем настраиваем в файле SQLConnectionSettings.json, библиотека DBLilbrary.  
Сейчас стоит MsSQL  

2) Программа написана на WPF  
Реализуем MVVM -паттерн с помощью интерфейсов для каждого окна (View)  

3) В проекте есть программа MAUI - MauiUniverApp. Её можно запустить, для этого назначить её в качестве ЗАПУСКАЕМОГо проекта.  
Там всё минимально - только можно посмотреть "О программе".  
Это для примера того, что мы можем использовать теже самые ViewModel  

4) Окна "ПОМОЩЬ" и "О ПРОГРАММЕ" тоже используют свои ViewModel-и,
которые получают данные из json-файлов:
- Help.json
- AboutProgramm.json
Библиотека HelpAndAboutProgrammLibrary  

5) В программе 2 роли:
- администратор
- менеджер  

файл RoleEnum.cs в библиотеке EntitiesLibrary/Enums  
У администратора будет меню "Администратор" в котором можно создать новую БД

