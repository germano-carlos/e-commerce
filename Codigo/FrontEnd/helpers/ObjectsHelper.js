class ObjectsHelper {

    static Contains(obj, list) {
        if(list) {
            var i;
            for (i = 0; i < list.length; i++) {
                if (list[i] === obj) {
                    return true;
                }
            }
        }

        return false;
    }
}

export default ObjectsHelper