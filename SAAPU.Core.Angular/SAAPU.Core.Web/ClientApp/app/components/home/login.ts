export class Login {
    username: string;
    password: string;
    permisos: Permiso[]
}

export class Permiso {
    nombre: string;

    constructor(nombre: string) {
        this.nombre = nombre;
    }
}