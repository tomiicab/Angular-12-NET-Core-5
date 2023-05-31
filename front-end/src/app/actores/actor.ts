export interface actorDTO{
    id: Number;
    nombre: string;
    fechaNacimiento: Date;
    foto: string;
    biografia: string;
}

export interface actorCreacionDTO{
    nombre: string;
    fechaNacimiento: Date;
    foto: File;
    biografia: string;
}