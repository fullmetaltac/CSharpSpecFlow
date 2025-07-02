Feature: Restaurant Checkout Calculation
  As a customer
  I want to receive the correct total bill including service charge and discounts
  So that I can pay the right amount

  Scenario: Group of 4 people order 4 starters, 4 mains and 4 drinks before 19:00
    Given the order includes:
      | Starters | Mains | Drinks | OrderTime           |
      | 4        | 4     | 4      | 2025-07-02T17:00:00 |
    When the checkout is requested
    Then the bill should consist of price 51.0, service charge 4.4 and total 55.4

  Scenario: Split order before and after 19:00
    Given the order includes:
      | Starters | Mains | Drinks | OrderTime           |
      | 1        | 2     | 2      | 2025-07-02T18:30:00 |
      | 0        | 2     | 2      | 2025-07-02T20:00:00 |
    When the checkout is requested
    Then the bill should consist of price 40.5, service charge 3.2 and total 43.7

  Scenario: One person cancels their order
    Given the order includes:
      | Starters | Mains | Drinks | OrderTime           |
      | 4        | 4     | 4      | 2025-07-02T18:00:00 |
    And a customer cancels 1 starter, 1 main, and 1 drink
    When the checkout is requested
    Then the bill should consist of price 38.25, service charge 3.3 and total 41.55
