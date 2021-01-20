<template>
  <div class="container">
    <h1>Hello World.. Vue is ...</h1>

    <form>
        <div class="w-100">
        <input type="text" v-model="$v.value.$model" @blur="handleBlur('value')" :class="($v.value.$invalid ? 'border border-danger': '')">
        <button :disabled="$v.$invalid" type="button" class="btn btn-success mx-2" @click="send"> {{ ($v.id == "" || $v.id == null) ? "Enviar" : "Salvar" }} </button>
        <!-- <button type="button" class="btn btn-info ml-2 " @click="getAll"> Teste </button> -->
        </div>
    </form>

    <div class="m-5 rounded">
        <table class="table table-striped table-dark table-hover">
            <thead class="">
                <tr>
                    <th scope="col" class="rounded-left border-0">Id</th>
                    <th scope="col" class="border-0">Msg</th>
                    <th scope="col" class="rounded-right border-0" colspan="2">Commands</th>
                </tr>
            </thead>
            <tbody>
                <tr :key="item.id" v-for="item in data">
                    <td> {{ item.id }} </td>
                    <td> {{ item.value }} </td>
                    <td> <button type="button" class="btn btn-danger" @click="remove(item.id)"> Remover </button> </td>
                    <td> <button type="button" class="btn btn-outline-info" @click="edit(item)"> Editar </button> </td>
                </tr>
            </tbody>
        </table>
    </div>
    
  </div>
</template>

<style scoped>
 input[type="text"]:focus{ outline: none; box-shadow: 0px 0px 5px #61C5FA; border:1px solid #5AB0DB; } input[type="text"]:hover{ border: 1px solid #999; border-radius: 5px; }
</style>

<script>
 import { reactive, ref, onMounted } from "vue"; 
 import { useVuelidate } from "@vuelidate/core";
 import { required, minLength } from "@vuelidate/validators";
 export default 
 { 
    setup() 
    { 
        const data = ref(null);

        const initValue = {id:"",value:""};
        const variavel = reactive({...initValue});

        const rules = {
            value : { 
                required, 
                minLength: minLength(8) 
            }
        };
        const $v = useVuelidate(
            rules, variavel 
        );
        const handleBlur = (key) =>{
            $v[key].$dirty = true;
        };


        onMounted(async () => await getAll());

        const send = async() => {

            //console.log($v.$error);
            $v.$dirty = true;
            if ($v.$error) {
                console.log($v.$error);
                return;
            }


            if (variavel.id != null && variavel.id != "")
                update();
            else
                add();
        }

        const add = async () => {
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(variavel.value)
            };
            const response = await fetch("https://localhost:5551/api/Crud", requestOptions);
            const result = await response.json();

            if (result == true)
                getAll();

            resetForm();
        }
        const remove = async (id) => {
            const requestOptions = {
                method: "DELETE",
                headers: { "Content-Type": "application/json" },
                //body: JSON.stringify(variavel.id)
            };
            const response = await fetch("https://localhost:5551/api/Crud/"+id, requestOptions);
            const result = await response.json();

            if (result == true)
                getAll();

        }
        const update = async (objeto) => {
            const requestOptions = {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(variavel)
            };
            const response = await fetch("https://localhost:5551/api/Crud", requestOptions);
            const result = await response.json();

            if (result == true)
                getAll();

            resetForm();
        }
        const getAll = async() => {
            const requestOptions = {
                method: "GET",
                headers: { "Content-Type": "application/json" },
                //body: JSON.stringify({ title: "Vue POST Request Example" })
            };
            const response = await fetch("https://localhost:5551/api/Crud", requestOptions);
            data.value = await response.json();
        }
        const edit = function(objeto){
            variavel.id = objeto.id;
            variavel.value = objeto.value;

            console.log(variavel);
        }

        function resetForm() {
        Object.assign(variavel, initValue);
        }

         return {send, update, remove, data, edit, $v, handleBlur}
    } 
};
</script>

