<?php
header('Content-Type: application/json');
// Function to get the client IP address
include 'environment_vars.php';

//var_dump($_POST);
if (!(isset($_POST['Fname']) && isset($_POST['Lname']) && isset($_POST['CountryID']) && isset($_POST['University']) && isset($_POST['EmailAdress']) && isset($_POST['Username']) && isset($_POST['BirthdayDate']) && isset($_FILES["file"]))) {
    echo json_encode(array("status" => 0, "error_message" => "missing fields"));
} else {

    //check if user exists
    $sql = "SELECT * FROM Inscriptions WHERE `Username`='" . $_POST['Username'] . "' AND `CountryID`='" . $_POST['CountryID'] . "'";
    $result = mysqli_query($connection, $sql) or die("Error in Selecting " . mysqli_error($connection));
    if ($result->num_rows) {
        header('Location: ../index.php?subscription=username&username=' . $_POST['Username']);
        die();

    } else {
        echo "username Ok !";
    }
    //check if email
    $sql = "SELECT * FROM Inscriptions WHERE `EmailAdress`='" . $_POST['EmailAdress'] . "' AND `CountryID`='" . $_POST['CountryID'] . "'";
    $result = mysqli_query($connection, $sql) or die("Error in Selecting " . mysqli_error($connection));
    if ($result->num_rows) {
        header('Location: ../index.php?subscription=email&email=' . $_POST['EmailAdress']);
        die();

    } else {
        echo "email Ok !";
    }

    $Picture = rand() . "_" . $_POST['Username'];
    $target_file = "../images/users/" . $Picture . ".jpg";
    if (getimagesize($_FILES["file"]["tmp_name"]) !== false && is_image($_FILES["file"]["tmp_name"]))
        if (move_uploaded_file($_FILES["file"]["tmp_name"], $target_file)) {
            $sql = 'INSERT INTO  Inscriptions (CEPic,CountryID,DateInsc,EmailAdress,Fname,Lname,Status,University,BirthdayDate,Username) VALUES ("' . $target_file . '","' . $_POST['CountryID'] . '","' . $date = date('Y-m-d H:i:s') . '","' . $_POST['EmailAdress'] . '","' . $_POST['Fname'] . '","' . $_POST['Lname'] . '","' . '0' . '","' . $_POST['University'] . '","' . $_POST['BirthdayDate'] . '","' . $_POST['Username'] . '")';
            $result = mysqli_query($connection, $sql) or die("Error in Selecting " . mysqli_error($connection));
            echo "request Ok !";
            header('Location: ../index.php?subscription=success');
            die();
            echo "uploaded under " . $target_file;
        } else {
            header('Location: ../index.php?subscription=image');
            die();
            //header('Location: ../index.php?subscription=error');
        }

    else {
        header('Location: ../index.php?subscription=image');
        die();
    }

}
function is_image($path)
{
    $a = getimagesize($path);
    $image_type = $a[2];

    if(in_array($image_type , array(IMAGETYPE_GIF , IMAGETYPE_JPEG ,IMAGETYPE_PNG , IMAGETYPE_BMP)))
    {
        return true;
    }
    return false;
}