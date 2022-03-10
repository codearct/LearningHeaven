# Templated Component-3

## Generic RenderFragment
- Most common usage of this generic type parameter RenderFragment is as repeater
- If we have list of books and you wanna show each book repeatedly following a custom template:
    ```
    List<Book> books;
    <Repeater Items ="books">
        @book.Title
        @book.Author
        @book.Genre
        @book.PublishDate
        @book.PageCount
    </Repeater>
    ```
- Custom generic RenderFragment created like:
    ```
    @typeparam TItem

    @foreach (var item in Items)
    {
        @Row(item)
    }

    @code {

        [Parameter]
        public RenderFragment<TItem> Row { get; set; }
    
        [Parameter]
        public List<TItem> Items { get; set; }

    }
    ```
