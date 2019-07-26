<template>
    <div>
        <div class="card" style="width: 18rem;" v-for="vault in vaults" :key="vault.id">
            <div class="card-body">
                <h5 class="card-title">{{vault.name}}</h5>
                <p class="card-text">{{vault.description}}</p>
                <button class="btn btn-danger" @click="deleteVault(vault.id)">deleteVault</button>
                <button class="btn btn-success" @click="enterVault(vault.id)">enterVault</button>
            </div>
        </div> 
    </div>
</template>

<script>
export default {
    name: "userVault", 
    computed: {
        vaults(){
            return this.$store.state.vaults
        }, 
        user() {
            return this.$store.state.user
        }
    },
    data() {
        return {}
    }, 
    methods: {
        enterVault(id){
            this.$store.dispatch("getVault", id) 
        }, 
        deleteVault(id){
            this.$store.dispatch("deleteVault", id) 
        }
    }
}
    

</script>

<style>
</style>
