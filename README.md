Dynamic Navigation
======

A proof of concept project.

Part 1 - Routes
-------
Routes can be defined from a dynamic source such as a database. Each route can have some associated data such as view, controller, model, variables, etc.
When the router catches a route change, an Ajax request is made to the server to collect route data for that path. Currently only a html view path is supported. This is then loaded into a container (also using Ajax).

Part 2 - Snapshots
-------
Snapshots are very important for SEO. By presenting snapshots when a request containing "_escaped_fragment_" comes in, this application supports indexing by search engines such as Google as well.

Tech
-------
ASP.NET vNext for backend.
Pure JS for front-end routing.

Additional info
-------
The application was initially developed on Mac OS as a test project. Currently the snapshot functions are not supported on Mono (Mac, Linux). But other normal navigation should work fine.

Next
-------
Next steps will most likely be in a new project as this project should just be a proof of concept.
- Multiple views rendered in order.
- Integrate with a front-end framework such as AngularJS or directly with ES6 components (via polymer maybe).
- DB storage (MongoDB or similar)
- Admin GUI
