Feature:Some tests on Verisk platform


Background: 


Scenario: User should be able to open quesry ticket by logining
  Given the user is on the "https://www.verisk.com/company/contact/" page
  And User clicks Acceptall button
  When User fills the Contact us form 
      | Field         | Value                     |
      | firstName     | TestingNamey               |
      | lastName      | TestSurnamye               |
      | businessEmail | ytestingtrtesting@gmail.com |
      | businessPhone | 073624746                |
      | company       | ABCytr Testing               |
      | comments      | Just Testingh              |
  Then user should be able to see success message "A Verisk associate will respond to your request soon."

