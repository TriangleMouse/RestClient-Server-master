<?php

$method = $_POST["method"];
switch ($method) {

#Чтение файла, 1 аргумент
    case 'GET':
$homepage = file_get_contents($_POST["arg0"]);
echo $homepage; #echo сам устанавливает header
        break;

# Перезапись файла, 2 аргумента [!Без применения! file_put_contents]
    case 'PUT':
        $filename = $_POST["arg0"];
        $file_handle = fopen($filename, "w");
        fwrite($file_handle, $_POST["arg1"]); 
        fclose($file_handle);
        header("HTTP/1.1 200 ReWrite OK");
        break;   
#Добавление в конец файла, 2 аргумента [!c применением! file_put_contents]

    case 'POST':
        file_put_contents($_POST["arg0"], $_POST["arg1"], FILE_APPEND | LOCK_EX);
        header("HTTP/1.1 200 POST OK");
        break;

#Удаление файла, 1 аргумент
    case 'DELETE':
        unlink($_POST["arg0"]);
        header("HTTP/1.1 200 DELETE OK");
        break;

#Копирование файла, 2 аргумента
    case 'COPY':
        copy($_POST["arg0"], $_POST["arg1"]);
        header("HTTP/1.1 200 Copy OK");
        break;

#Перемещение файла, 2 аргумента
    case 'MOVE':
        copy($_POST["arg0"], $_POST["arg1"]);
        unlink($_POST["arg0"]);
        header("HTTP/1.1 200 Move OK");
    break;
#STATUS        
    case 'STATUS':
        header("HTTP/1.1 200 STATUS OK");
break;          
       
    
    default:
    header("HTTP/1.1 405 Method Not Allowed");
        break;
}
