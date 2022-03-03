# Communication Between Components

## Reference
- Sometimes from parent component wen want to directly invoke the methods or properties of child component outside of the declaration
-  Example:
    ```
    <button class="btn btn-outline-secondary" @onclick=@(()=> child.Show())>//Use child's method and props
    Show Child Component
    </button>
    <br />
    <br />
    <ChildComponent @ref="child"/>//Give reference child component for used its methods and properties by parent

    @code {
        public ChildComponent child;

        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }
    }
    ```