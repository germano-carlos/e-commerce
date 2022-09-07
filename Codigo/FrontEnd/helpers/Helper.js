class Helper {
    static especialCharMask(especialChar) {
        especialChar = especialChar.replace('/[áàãâä]/ui', 'a');
        especialChar = especialChar.replace('/[éèêë]/ui', 'e');
        especialChar = especialChar.replace('/[íìîï]/ui', 'i');
        especialChar = especialChar.replace('/[óòõôö]/ui', 'o');
        especialChar = especialChar.replace('/[úùûü]/ui', 'u');
        especialChar = especialChar.replace('/[ç]/ui', 'c');
        especialChar = especialChar.replace('/[^a-z0-9]/i', '_');
        especialChar = especialChar.replace('/_+/', '_'); //
        return especialChar;
    }
}

export default Helper