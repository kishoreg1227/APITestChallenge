Feature: WeatherDataForSeveralCities
	In order to display the weather data for several cities in my application
	As an data analyst
	I want to be told the weather data for multiple cities

Scenario Outline: Validate the weather data for cities with in a rectangle zone
	Given I set the following bounding box parameters <lon-left>,<lat-bottom>,<lon-right>,<lat-top>,<zoom>
	When I execute the API call on 'box/city' the endpoint
	Then following should be available in the response content <result>

Examples: 
| lon-left | lat-bottom | lon-right | lat-top | zoom | result |
| 12       | 32         | 15        | 37      | 10   |  15    |