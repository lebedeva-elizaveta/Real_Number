# Задача 1
## Вариант 10
### Класс «Вещественное число».
В каждой задаче необходимо создать класс, членами которого являются указанные поля и методы. Интерфейс к задаче желательно выполнить на форме (WPF) с использованием компонентов. Нужно придерживаться модели MVVM. Можно реализовать консольное приложение, но оценка за это будет снижена.
На что следует обратить внимание (за невыполнение оценка будет снижена): 
- Обязательно классы реализуются в отдельном модуле. 
- Программа оформляется в соответствии с требованиями к разработке ПО (отступы, названия переменных и т.п.). 
- В конструкторе класса могут и должны быть настроены значения полей и свойств класса, но инициализация значений должна быть вне класса. Например, не следует в конструкторе класса задавать в списке какие-то значения, или какое-то имя студента, если они не передаются в конструктор через параметр.
  
**Свойства:** знак, мантисса, порядок. Мантисса должна быть неотрицательным числом, допускается при значении мантиссы 0 порядок отличный от 0 (т.е. 0*10n). Если задаётся мантисса больше 10 или меньше 1, то привести её к числу меньше 10 или больше 1 и добавить соответствующие степени в порядок (например, если задаётся 100, то представить как 10 и увеличить порядок на 1, или если 0,01, то представить как 1 и уменьшить порядок на 2).
**Методы:** представление числа в виде строки (можно перекрыть метод ToString(), число представляется в виде Знак Мантисса E Порядок), сравнения, сложения, вычитания, умножения и деления  двух вещественных чисел.
