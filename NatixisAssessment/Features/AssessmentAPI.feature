Feature: Assessment API
API Validation
Scenario: Check how many Covid critical cases
	Given the url and the endpoint '/v2/countries/Portugal?yesterday'
	When the request is submited
	Then the response should have status code 200
	And the critical cases should be less than 100