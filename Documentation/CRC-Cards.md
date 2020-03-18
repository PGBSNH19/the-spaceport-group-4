**Rev2 2020-03-18**

**Class SpacePort**

| **Responsibility**                                           | **Collaborators** |
| ------------------------------------------------------------ | ----------------- |
| Different lists of type Port eg: List<Port> LargeShip        | Port              |
| Ex:List<Port> StarfighterList<Port> CorvetteList<Port> Landing craft | Menu              |
|                                                              | ValidateCustomer  |



**Class Port**

| **Responsibility** | **Collaborators** |
| ------------------ | ----------------- |
| Bool Available     | SpacePort         |

- Parkinglot-item in SpacePort

- Instantiate different amounts into different lists. Eg instantiate 10 port in List<Port> Large ships

- - This list is inside Class Spaceport

**Class Menu**

| **Responsibility**                  | **Collaborators**  |
| ----------------------------------- | ------------------ |
| DisplayMenu()                       | ValidateCustomer   |
| DisplayShipTypes()                  | Static void Main() |
| CustomerSignIn() : Console Readline | Port               |

- DisplayMenu() : Welcome text, etc

- DisplayShipTypes(): Choose shipType, Array[ ] Options, piltagenter upp ner

- - Port: Check if there are any spots avaliable

  - - No, meddelande/ Yes proceed

- CustomerSignIn(): “What is your name?” : Console.readline()

- - Validate Customer: Check name mot API sw personer



**Class ValidateCustomer**

| **Responsibility**                                       | **Collaborators** |
| -------------------------------------------------------- | ----------------- |
| ValidateName (string validateName): från menu            | API request       |
| API Metod tex check data where data.name == validateName | Menu              |
|                                                          | Ticket            |

- Kontrollera inskrivet namn från Menu, mot API
- Någon slags felkontroll, för att förhindra felskrivningar, tex bara små bokstäver



**Class Ticket (database item)**

| **Responsibility**     | **Collaborators** |
| ---------------------- | ----------------- |
| TicketID               | ValidateCustomer  |
| Shipsize               | Menu              |
| Date/time of arrival   |                   |
| Date/time of departure |                   |



**Class Receipt (database item)**

| **Responsibility** | **Collaborators** |
| ------------------ | ----------------- |
| RecieptID          | Ticket            |
| TicketID           |                   |
| TotalPrice         |                   |

- TotalPrice får inte vara noll eller minus ParkingFee().



**Rev1 2020-03-18**



**Class Port**

| **Responsibility**     | **Collaborators** |
| ---------------------- | ----------------- |
| ID                     | ValidateCustomer  |
| Available              | SpacePark         |
| Size                   |                   |
| CheckLotAvaliability() |                   |



**Class Menu**

| **Responsibility** | **Collaborators**  |
| ------------------ | ------------------ |
| DisplayMenu()      | ValidateCustomer   |
| Step1()            | Static void Main() |
| Step2()            | Port               |
|                    |                    |

- DisplayMenu() : Welcome text, etc

- Step1(): Choose shipType, Array[ ] Options, piltagenter upp ner

- - Port: Check if there are any spots avaliable

  - - No, meddelande/ Yes proceed

- Step2(): “What is your name?” : Console.readline()

- - Validate Customer: Check name mot API sw personer



**Class ValidateCustomer**

| **Responsibility**                 | **Collaborators** |
| ---------------------------------- | ----------------- |
| ValidateName (string validateName) | API request       |
|                                    | Customer          |
|                                    | Spaceship         |
|                                    | Check-in          |
|                                    | Port              |
|                                    | Menu              |

- Kontrollera om det finns plats på port, annars meddela

- Kontrollera att customer är en sw person, mot vilken lista då?

- Kontrollera skepp

- ValidateName(), input from user, check against names in API

- - Kan behöva någon sorts formatering beroende på hur text är formaterad i API





**Class spaceship**

| **Responsibility** | **Collaborators** |
| ------------------ | ----------------- |
| ID                 | Passengers        |
| Name               | port              |
| Size               |                   |



**identifiera skeppet och dess egenskaper, dvs storleken och namnen**





**Class Receipt**

| **Responsibility** | **Collaborators** |
| ------------------ | ----------------- |
| ID                 | Traveler          |
| Time               |                   |
| TotalPrice         |                   |

- Kontrollera att parkeringen startades innan den avslutades Parked().
- TotalPrice får inte vara noll eller minus ParkingFee().





**Class Travelers**

| **Responsibility**      | **Collaborators** |
| ----------------------- | ----------------- |
| ID                      | Spaceship         |
| Name                    | Receipt           |
| is member of star wars? |                   |



To identify travelers if they are members of star wars.