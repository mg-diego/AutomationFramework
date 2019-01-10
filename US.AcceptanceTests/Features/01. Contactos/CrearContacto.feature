Feature: CrearContacto


Scenario: Crear Contacto - User can open 'Crear Contacto'
	Given A valid user completes the login process
	When The user clicks Crear Contacto
	Then The user is at Create New Contact

Scenario Outline: Crear Contacto - Name field is mandatory
	Given A valid user completes the login process 
	And The user clicks Crear Contacto
	When The user creates new user without '<field>'
	Then Error message for '<field>' mandatory field appears

	Examples:
		| field |
		| name  |
		| email |
		| phone |

