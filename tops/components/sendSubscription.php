<?php
header('Content-Type: application/json');
// Function to get the client IP address
include 'environment_vars.php';

//var_dump($_POST);
if (!(isset($_POST['Fname']) && isset($_POST['Lname']) && isset($_POST['CountryID']) && isset($_POST['University']) && isset($_POST['EmailAdress']) && isset($_POST['Username']) && isset($_POST['BirthdayDate']))) {
    echo json_encode(array("status" => 0, "error_message" => "missing fields"));
} else {

    //check if user exists
    $sql = "SELECT * FROM Inscriptions WHERE Username='" . $_POST['Username']."'";
    $result = mysqli_query($connection, $sql) or die("Error in Selecting " . mysqli_error($connection));
    if ($result->num_rows) {
        header('Location: ../index.php?subscription=username&username='.$_POST['Username']);

    } else {
        echo "username Ok !";
    }
    //check if email
    $sql = "SELECT * FROM Inscriptions WHERE EmailAdress='" . $_POST['EmailAdress']."'";
    $result = mysqli_query($connection, $sql) or die("Error in Selecting " . mysqli_error($connection));
    if ($result->num_rows) {
        header('Location: ../index.php?subscription=email&email='.$_POST['EmailAdress']);

    } else {
        echo "email Ok !";
    }

    $Picture = rand() ."_". $_POST['Username'];
    $target_file = "../images/users/" . $Picture . ".jpg";
    if (getimagesize($_FILES["file"]["tmp_name"]) !== false)
        if (move_uploaded_file($_FILES["file"]["tmp_name"], $target_file)) {
            $sql = 'INSERT INTO  Inscriptions (CEPic,CountryID,DateInsc,EmailAdress,Fname,Lname,Status,University,BirthdayDate,Username) VALUES ("'.$target_file.'","'.$_POST['CountryID'].'","'.$date = date('Y-m-d H:i:s').'","'.$_POST['EmailAdress'].'","'.$_POST['Fname'].'","'.$_POST['Lname'].'","'.'0'.'","'.$_POST['University'].'","'.$_POST['BirthdayDate'].'","'.$_POST['Username'].'")';
            $result = mysqli_query($connection, $sql) or die("Error in Selecting " . mysqli_error($connection));
            echo "request Ok !";
            header('Location: ../index.php?subscription=success');
            echo "uploaded under " . $target_file;
        } else
        {
            echo "error uploading image";
            //header('Location: ../index.php?subscription=error');
        }

    else {
        echo "error uploading image";
    }

}