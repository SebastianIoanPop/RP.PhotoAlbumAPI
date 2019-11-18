# RunPath test

API Endpoints:
- localhost:44323/api/photoalbum
- localhost:44323/api/photoalbum?userId=1 (or any other userId desired)

# Brief description
Create a Web API that when called:
- Calls, combines and returns the results of:
    - http://jsonplaceholder.typicode.com/photos
    - http://jsonplaceholder.typicode.com/albums
- Allows an integrator to filter on the user id – so just returns the albums and photos relevant
to a single user.