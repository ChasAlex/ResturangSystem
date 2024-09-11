# Restaurant System API Documentation

The API will start on `http://localhost:5000`.

## API Endpoints

### BokningController (Booking)

**Base URL:** `/api/bokning`

#### Get All Bookings
- **URL:** `GET /getAll`
- **Response:**
  - `200 OK` with a list of bookings.
  - `500 Internal Server Error` if something goes wrong.

#### Get Booking by ID
- **URL:** `GET /get/{id}`
- **Response:**
  - `200 OK` with the booking details.
  - `500 Internal Server Error` if something goes wrong.

#### Create Booking
- **URL:** `POST /add`
- **Body:** `BokningDTO` (JSON)
- **Response:**
  - `200 OK` with the created booking.
  - `500 Internal Server Error` if something goes wrong.

#### Update Booking
- **URL:** `PUT /update`
- **Body:** `BokningDTO` (JSON)
- **Response:**
  - `200 OK` with the updated booking.
  - `500 Internal Server Error` if something goes wrong.

#### Delete Booking
- **URL:** `DELETE /delete/{id}`
- **Response:**
  - `200 OK` on successful deletion.
  - `500 Internal Server Error` if something goes wrong.

### BordController (Table)

**Base URL:** `/api/bord`

#### Get All Tables
- **URL:** `GET /getAllBord`
- **Response:**
  - `200 OK` with a list of tables.
  - `500 Internal Server Error` if something goes wrong.

#### Get Table by ID
- **URL:** `GET /getBord/{id}`
- **Response:**
  - `200 OK` with the table details.
  - `500 Internal Server Error` if something goes wrong.

#### Create Table
- **URL:** `POST /addBord`
- **Body:** `BordDTO` (JSON)
- **Response:**
  - `200 OK` on successful creation.
  - `500 Internal Server Error` if something goes wrong.

#### Update Table
- **URL:** `PUT /updateBord`
- **Body:** `BordDTO` (JSON)
- **Response:**
  - `200 OK` on successful update.
  - `500 Internal Server Error` if something goes wrong.

#### Delete Table
- **URL:** `DELETE /deleteBord/{id}`
- **Response:**
  - `200 OK` on successful deletion.
  - `500 Internal Server Error` if something goes wrong.

#### Get Available Tables
- **URL:** `POST /getAvailableBords`
- **Body:** `AvailableTableDTO` (JSON)
- **Response:**
  - `200 OK` with a list of available tables.
  - `400 Bad Request` if the input is invalid.

### KundController (Customer)

**Base URL:** `/api/kund`

#### Get All Customers
- **URL:** `GET /getAllKund`
- **Response:**
  - `200 OK` with a list of customers.
  - `500 Internal Server Error` if something goes wrong.

#### Get Customer by ID
- **URL:** `GET /getKund/{id}`
- **Response:**
  - `200 OK` with the customer details.
  - `500 Internal Server Error` if something goes wrong.

#### Create Customer
- **URL:** `POST /addKund`
- **Body:** `KundDTO` (JSON)
- **Response:**
  - `200 OK` on successful creation.
  - `500 Internal Server Error` if something goes wrong.

#### Update Customer
- **URL:** `PUT /updateKund`
- **Body:** `KundDTO` (JSON)
- **Response:**
  - `200 OK` on successful update.
  - `500 Internal Server Error` if something goes wrong.

#### Delete Customer
- **URL:** `DELETE /deleteKund/{id}`
- **Response:**
  - `200 OK` on successful deletion.
  - `500 Internal Server Error` if something goes wrong.

### MenyController (Menu)

**Base URL:** `/api/meny`

#### Get All Menus
- **URL:** `GET /getAllMeny`
- **Response:**
  - `200 OK` with a list of menus.
  - `500 Internal Server Error` if something goes wrong.

#### Get Menu by ID
- **URL:** `GET /getMeny/{id}`
- **Response:**
  - `200 OK` with the menu details.
  - `500 Internal Server Error` if something goes wrong.

#### Create Menu
- **URL:** `POST /addMeny`
- **Body:** `MenyDTO` (JSON)
- **Response:**
  - `200 OK` on successful creation.
  - `500 Internal Server Error` if something goes wrong.

#### Update Menu
- **URL:** `PUT /updateMeny`
- **Body:** `MenyDTO` (JSON)
- **Response:**
  - `200 OK` on successful update.
  - `500 Internal Server Error` if something goes wrong.

#### Delete Menu
- **URL:** `DELETE /deleteMeny/{id}`
- **Response:**
  - `200 OK` on successful deletion.
  - `500 Internal Server Error` if something goes wrong.

### ResturangController (Restaurant)

**Base URL:** `/api/resturang`

#### Get All Restaurants
- **URL:** `GET /getAllResturang`
- **Response:**
  - `200 OK` with a list of restaurants.
  - `500 Internal Server Error` if something goes wrong.

#### Get Restaurant by ID
- **URL:** `GET /getResturang/{id}`
- **Response:**
  - `200 OK` with the restaurant details.
  - `500 Internal Server Error` if something goes wrong.

#### Create Restaurant
- **URL:** `POST /addResturang`
- **Body:** `ResturangDTO` (JSON)
- **Response:**
  - `200 OK` on successful creation.
  - `500 Internal Server Error` if something goes wrong.

#### Update Restaurant
- **URL:** `PUT /updateResturang`
- **Body:** `ResturangDTO` (JSON)
- **Response:**
  - `200 OK` on successful update.
  - `500 Internal Server Error` if something goes wrong.

#### Delete Restaurant
- **URL:** `DELETE /deleteResturang/{id}`
- **Response:**
  - `200 OK` on successful deletion.
  - `500 Internal Server Error` if something goes wrong.
