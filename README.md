### Feature description:

You are testing a checkout system for a restaurant. There is a new endpoint that will
calculate the total of the order, and add a 10% service charge on food.
The restaurant only serves starters, mains and drinks, and the set cost for each is:

**Starters** cost £4.00  
**Mains** cost £7.00  
**Drinks** cost £2.50  
Drinks have a 30% discount when ordered before 19:00

### Scenarios:
Write tests to cover the following Scenarios:

1. A group of 4 people order 4 starters, 4 mains and 4 drinks. The endpoint returns a correctly calculated bill

```starters:		4 * 4 = 16```  
```mains:			4 * 7 = 28```  
```drinks:		4 * 2.5 * 0.7 = 7```  
```charge:		10% = 4.4```  
```price:			16 + 28 + 7 = 51```  
```total:			51 + 4.4 = 54.4```	

2. A group of 2 people order 1 starter and 2 mains and 2 drinks before 19:00. The bill is requested and the correct amount is shown on the bill.
The group of two people are then joined by 2 more people at 20:00 who order 2 mains and 2 drinks, when the party is ready to leave the final bill is requested and is correct.

```starters#1:		1 * 4 = 4```  
```mains#1:		2 * 7 = 14```  
```drinks#1:		2 * 2.5 * 0.7 = 3.5```  
```charge#1:		10% = 1.8```  
  

```starters#2:		2 * 7 = 14```  
```drinks#2:		2 * 2.5  = 5```  
```charge#2:		10% = 1.4```  
  
```price:			4 + 14 + 3.5 + 14 + 5 = 40.5```  
```charge:		10% = 3.2```  
```total:			40.5 + 3.2 = 43.7```  

3. A group of 4 people order a starter, 1 mains and a drink each. The bill is requested and correctly calculated. A member of the group cancels their order and the order is now updated to reflect one member of the party leaving.  A final bill is requested as the party is ready to leave and final amount is correct and reflects the changes to the group.

```starters#1:		4 * 4  = 16```  
```mains#1:		4 * 7  = 28```  
```drinks#1:		4 * 2.5 = 10```  
```charge#1:		10% = 4.4```  

```cancelation```  

```starters#2:		3 * 4 = 12```  
```mains#2:		3 * 7 = 21```  
```drinks#2:		3 * 2.5 * 0.7 = 5.25```  
```charge#2		10% = 3.3```  

```price:			12 + 21 + 5.25 = 38.25```  
```charge:		10% = 3.3```  
```total:			38.25 + 3.3 = 41.55```  

### Requirements:
- Please create a class/method that represents the above requirements and write the associated test cases with any test framework of your choice.
- Once complete upload the project to your Gitub account and forward the Github url within the timeframe specified.
- Please note any assumptions made to be captured in your project submission
- The project must compile, as we’ll be stepping through it on review
- USE Gherkin style test documentation
- Use SpecFlow as part of your submission
- Please write your submission in C-Sharp