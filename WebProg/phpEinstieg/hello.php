<!DOCTYPE html>
<html>

<head>
    <title>PHP Test</title>
</head>

<body>
    <?php echo '<p>Hello World</p>'; ?>
    <!-- <?php phpinfo(); ?> -->
    <?php
    echo $_SERVER['HTTP_USER_AGENT'];
    ?>
    <?php
    if (strpos($_SERVER['HTTP_USER_AGENT'], 'MSIE') !== FALSE) {
    ?>
        <h3>strpos() must have returned non-false</h3>
        <p>You are using Internet Explorer</p>
    <?php
    } else {
    ?>
        <h3>strpos() must have returned false</h3>
        <p>You are not using Internet Explorer</p>
    <?php
    }
    ?>
    <!-- Handling forms -->
    <form action="action.php" method="post">
        <p>Your name: <input type="text" name="name" /></p>
        <p>Your age: <input type="text" name="age" /></p>
        <p>Your email: <input type="email" name="email" /></p>
        <p><input type="submit" /></p>
    </form>
    <form action="index.html" method="post">
        <p><input type="submit" value="Dont Click it! I Warned You!" /></p>
    </form>
    <form action="troll.html">
        <p><input type="submit" value="Dont Click it! I Warned You!" /></p>
    </form>
</body>

</html>