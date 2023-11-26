Feature: withdraw

@withdraw
Scenario Outline: Customer withdraw with valid data
    Given Customer with details:<Name>,<Amount>
    When I log in as a "Customer"
    And I navigate to "Withdraw" page
    And fill the data
    And I submit the form
    Then Message should be Transaction Successful

    Examples: 
    | Name             | Amount |
    | Hermoine Granger | 140    |
    | Hermoine Granger | 15     |
    | Hermoine Granger | 230    |

@withdrawNoMessage
Scenario Outline: Customer withdraw with wrong data
    Given Customer with details:<Name>,<Amount>
    When I log in as a "Customer"
    And I navigate to "Withdraw" page
    And fill the data
    And I submit the form
    Then Message shouldn't be displayed
    
    Examples: 
    | Name               | Amount |
    | Harry Potter       | 0      |
    | Ron Weasly         | -1     |
    | Albus Dumbledore   | -123   |
    | Neville Longbottom | -140   |
    | Ron Weasly         |        |

    @withdrawError
    Scenario Outline: Customer withdraw with bigger data
    Given Customer with details:<Name>,<Amount>
    When I log in as a "Customer"
    And I navigate to "Withdraw" page
    And fill the data
    And I submit the form
    Then Message should be Transaction Failed. You can not withdraw amount more than the balance.
    
    Examples: 
    | Name               | Amount |
    | Albus Dumbledore   | 50     |
    | Harry Potter       | 420    |
    | Ron Weasly         | 3000   |
   