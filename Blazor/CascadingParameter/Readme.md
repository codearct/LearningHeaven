# Communication Between Components-3
## Cascading Parameters
- You have complex components tree which contains several levels of component
- You want to pass a parameter value from the first level to last level
- You can use to cascade a value from whichever level downward to the lower level component so you don't need to cascade one by one
![Cascading Parameter](https://github.com/codearct/LearningHeaven/blob/master/Blazor/CascadingParameter/Img/Cascading.PNG)
- You can use multiple cascading parameters(nested)
- Avoid using cascading parameter too much because of performance issue 
- Parent component:
  ```
    <CascadingValue Name="Counter" Value=@currentCount>
    <CascadingValue Name="TitleColor" Value=@("blue ") IsFixed=true>
        <SubComponent1/> 
    </CascadingValue>    
    </CascadingValue>

    @code {
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }
    }
    ```
- Wrap first sub level component of tree with "CascadingValue" inside parent component. Name it and give its value. It would be variable or fixed value
- Sub Child Component:
    ```
    <div class="ms-3">
        <h3>
            SubComponent1
        </h3> 
        <SubComponent2/>
    </div>
    ```
- Last or Target Child Component:
    ```
    <div class="ms-4">
        <h3 style="color:@Color">
            SubComponent2
        </h3> 
        Count: @CascadingValue
    </div>

    @code {

        [CascadingParameter(Name = "Counter")]
        public int CascadingValue { get; set; }

        [CascadingParameter(Name = "TitleColor")]
        public string Color { get; set; }

    }
    ```
- Declare CascadingParameter with name which created inside parent component in target component
- You would give name what you want but you must assign with the attribute
- Then use it/them at component html part with the name that you give

- Be carefull while you are using CascadingParameter because we can not follow where to declare CascadingValue
- We should use cascading parameter from up to down.It won't work from down to up 
