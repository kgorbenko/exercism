using System;
using Xunit;

public class BookStoreTests
{
    [Fact]
    public void Only_a_single_book()
    {
        var basket = new[] { 1 };
        Assert.Equal(8m, BookStore.Total(basket));
    }

    [Fact]
    public void Two_of_the_same_book()
    {
        var basket = new[] { 2, 2 };
        Assert.Equal(16m, BookStore.Total(basket));
    }

    [Fact]
    public void Empty_basket()
    {
        var basket = Array.Empty<int>();
        Assert.Equal(0m, BookStore.Total(basket));
    }

    [Fact]
    public void Two_different_books()
    {
        var basket = new[] { 1, 2 };
        Assert.Equal(15.2m, BookStore.Total(basket));
    }

    [Fact]
    public void Three_different_books()
    {
        var basket = new[] { 1, 2, 3 };
        Assert.Equal(21.6m, BookStore.Total(basket));
    }

    [Fact]
    public void Four_different_books()
    {
        var basket = new[] { 1, 2, 3, 4 };
        Assert.Equal(25.6m, BookStore.Total(basket));
    }

    [Fact]
    public void Five_different_books()
    {
        var basket = new[] { 1, 2, 3, 4, 5 };
        Assert.Equal(30m, BookStore.Total(basket));
    }

    [Fact]
    public void Two_groups_of_four_is_cheaper_than_group_of_five_plus_group_of_three()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 5 };
        Assert.Equal(51.2m, BookStore.Total(basket));
    }

    [Fact]
    public void Two_groups_of_four_is_cheaper_than_groups_of_five_and_three()
    {
        var basket = new[] { 1, 1, 2, 3, 4, 4, 5, 5 };
        Assert.Equal(51.2m, BookStore.Total(basket));
    }

    [Fact]
    public void Group_of_four_plus_group_of_two_is_cheaper_than_two_groups_of_three()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 4 };
        Assert.Equal(40.8m, BookStore.Total(basket));
    }

    [Fact]
    public void Two_each_of_first_four_books_and_one_copy_each_of_rest()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5 };
        Assert.Equal(55.6m, BookStore.Total(basket));
    }

    [Fact]
    public void Two_copies_of_each_book()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        Assert.Equal(60m, BookStore.Total(basket));
    }

    [Fact]
    public void Three_copies_of_first_book_and_two_each_of_remaining()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1 };
        Assert.Equal(68m, BookStore.Total(basket));
    }

    [Fact]
    public void Three_each_of_first_two_books_and_two_each_of_remaining_books()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 1, 2 };
        Assert.Equal(75.2m, BookStore.Total(basket));
    }

    [Fact]
    public void Four_groups_of_four_are_cheaper_than_two_groups_each_of_five_and_three()
    {
        var basket = new[] { 1, 1, 2, 2, 3, 3, 4, 5, 1, 1, 2, 2, 3, 3, 4, 5 };
        Assert.Equal(102.4m, BookStore.Total(basket));
    }

    [Fact]
    public void Check_that_groups_of_four_are_created_properly_even_when_there_are_more_groups_of_three_than_groups_of_five()
    {
        var basket = new[] { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 5, 5 };
        Assert.Equal(145.6m, BookStore.Total(basket));
    }

    [Fact]
    public void One_group_of_one_and_four_is_cheaper_than_one_group_of_two_and_three()
    {
        var basket = new[] { 1, 1, 2, 3, 4 };
        Assert.Equal(33.6m, BookStore.Total(basket));
    }

    [Fact]
    public void One_group_of_one_and_two_plus_three_groups_of_four_is_cheaper_than_one_group_of_each_size()
    {
        var basket = new[] { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5 };
        Assert.Equal(100m, BookStore.Total(basket));
    }
}
