# Communication Between Components

## Routing Parameter
- Route parameters are used to help us communicate between page components as well as between non-page components and page components
- TeamsComponent communicates with TeamComponent like below:
![Route Parameter](Img/RouteParams.png)
- Like as:
    ```
    [Route("/teams/{id}")] //fed by TeamsComponent
    public Team TeamComponent(int id)//fed by Route
    {
        ...
    }
    ``` 
