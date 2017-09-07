fun main(args: Array<String>) {
    var persona = Persona("Ariel", 36)
    println(persona.getDescripcion());
}

class Persona(var nombre: String, var edad: Int) {
    fun getDescripcion() : String {
        return this.nombre
    }
}