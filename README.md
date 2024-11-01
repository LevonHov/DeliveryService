Описание проекта
Delivery_Service — это консольное приложение для службы доставки, которое позволяет фильтровать заказы по определенным критериям.
Программа считывает данные о заказах из файла, фильтрует заказы по заданному району и временным параметрам, а затем сохраняет 
результат в указанный файл. Вся информация о процессе работы приложения и возможные ошибки логируются для упрощения диагностики и контроля работы программы.

Основные возможности:
1.Считывание данных о заказах из файла.
2.Фильтрация заказов по району и времени доставки.
3.Сохранение отфильтрованных заказов в файл.
4.Логирование основных операций и ошибок.

Компоненты
1.Order.cs: модель данных, представляющая информацию о заказе.
2.OrderRepository.cs: отвечает за чтение и запись данных о заказах в файл.
3.OrderService.cs: реализует бизнес-логику для фильтрации и обработки заказов.
4.LogService.cs: управляет логированием операций и ошибок в процессе выполнения программы.
5.Program.cs: основной файл программы, который взаимодействует с пользователем и вызывает необходимые методы для выполнения операций. Требования

Пример ввода:
Enter the path to the orders file: ./data/orders.csv
Enter the path to the results file: ./data/orders.csv
Enter the district for filtering: Center
Enter the time for the first delivery (format: yyyy-MM-dd HH:mm:ss): 2024-11-01 10:30:00
Enter the log file name (e.g., delivery.log): LogFile

Формат файла заказов

OrderId,Weight,District,DeliveryTime

Пример:
1,5.5,Center,2024-11-01 10:00:00
2,3.0,North,2024-11-01 10:15:00
3,7.8,Center,2024-11-01 10:45:00


