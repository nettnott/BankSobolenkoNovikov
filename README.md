# Практическая работа №6 — Создание автоматизированных Unit-тестов

## Цель работы

Провести тестирование разработанных программных модулей с использованием средств автоматизации Microsoft Visual Studio методом «белого ящика».

---

## Структура проекта

```
Bank.sln
├── Bank/
│   ├── Bank.csproj
│   └── BankAccount.cs
└── BankTests/
    ├── BankTests.csproj
    └── BankAccountTests.cs
```

---

## Скриншоты

### 1. Запуск консольного приложения

### 2. Результат тестов

*(вставить скриншот зелёных тестов)*

---

## Обнаруженная ошибка

Тест `Debit_WithValidAmount_UpdatesBalance` показал, что баланс увеличивается вместо уменьшения.

Причина — ошибка в методе `Debit`:
```csharp
// Было (баг):
m_balance += amount;

// Стало (исправление):
m_balance -= amount;
```

---

## Результаты тестирования

| Тест | Результат |
|------|-----------|
| `Debit_WithValidAmount_UpdatesBalance` | ✅ Пройден |
| `Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange` | ✅ Пройден |
| `Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange` | ✅ Пройден |
| `Credit_WithValidAmount_UpdatesBalance` | ✅ Пройден |
| `Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange` | ✅ Пройден |
| `Credit_WithZeroAmount_BalanceUnchanged` | ✅ Пройден |

---

## Вывод

В ходе работы был написан модульный тест, который сразу обнаружил ошибку в методе `Debit`: вместо вычитания суммы из баланса она прибавлялась (`+=` вместо `-=`). После исправления тест прошёл успешно.

Затем методы `Debit` были доработаны — добавлены константы с описательными сообщениями об ошибках, а тесты переписаны с использованием `try/catch` и `StringAssert.Contains` для точной проверки текста исключения.

Самостоятельно написаны 3 теста для метода `Credit`. Всего — **6 тестов**, все успешно пройдены.

Модульное тестирование позволяет находить ошибки на раннем этапе и делать код надёжнее.
