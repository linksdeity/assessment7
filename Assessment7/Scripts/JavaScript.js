function DeleteChoice(dishID) {
    if (confirm('Are you sure you want to delete???')) {
        window.location.href = "/Home/DeleteDish/" + dishID;
    } else {
        return false;
    }
}