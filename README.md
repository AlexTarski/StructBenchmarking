В проекте реализованы эксперименты по замеру производительности использования структур и классов.
Эти эксперименты дадут общее понимание, в каких случаях структуры могут быть полезны, а в каких наоборот вредны.

Версия 1.
Реализован тестовый функционал бенчмарка, позволяющий измерить производительность отдельных участков кода.
В качестве теста использовано создание строки, состоящей из 10_000 символов «а», реализованное с помощью
(*1)СтрингБилдера и (*2) специализированного конструктора строки.
1.Создать StringBuilder, много раз вызвать Append, а в конце вызвать у него ToString().
2.Вызвать специализированный конструктор строки new string('a', 10000).

Количество повторений выбрано произвольно.

С помощью Assert.Less проверяет, что специализированный конструктор строки работает быстрее, чем StringBuilder.


Версия 1.1.
Реализован полный функционал бенчмарка, отражающий на графиках:
1. Зависимость времени создания массива структур/классов от количества полей в структуре/классе;
(массивы классов создаются дольше массивов структур)
2. Зависимость времени передачи структуры/класса в метод в зависимости от их размера;
(большие классы передаются в метод быстрее больших структур)

