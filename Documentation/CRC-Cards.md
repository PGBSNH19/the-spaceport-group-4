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