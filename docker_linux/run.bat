docker build . -t mylinux_image

docker run --volume /extenral_folder:../attached_folder --rm -it --name=mylinux mylinux_image

docker attach mylinux 


@rem --rm - контейнер удаляется после выключения
@rem -it - контейнер после запуска типа остается в режиме ожидания. 
@rem -d - контейнер во время выполнения (или режима ожидания) не занимает текущую консоль